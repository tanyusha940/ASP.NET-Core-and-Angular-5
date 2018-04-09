import { Component, OnInit } from '@angular/core';
import { UsersItem } from '@app/admin-page/admin/models/userItem';
import { UsersService } from '@app/admin-page/admin/users.service';
import { I18nService } from '@app/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  userItem: UsersItem[];
  constructor(
    private userService: UsersService,
    private i18nService: I18nService
  ) { }

  async ngOnInit() {
    await this.refreshUserList();
  }

  setLanguage(language: string) {
    this.i18nService.language = language;
  }

  get currentLanguage(): string {
    return this.i18nService.language;
  }
  get languages(): string[] {
    return this.i18nService.supportedLanguages;
  }

  async blockUser(item: UsersItem) {
    await this.userService.toggleBlockUser(item.id);
    await this.refreshUserList();
  }

  async refreshUserList() {
    this.userItem = await this.userService.getUsers();
    this.userItem.forEach(async(user) => {
      user.isAdmin = await this.isAdmin(user);
    });
  }

  getBlockButtonText(item: UsersItem): string {
    return (item.active) ? 'block' : 'unblock';
  }

  getAdminButtonText(item: UsersItem): string {
    return (item.isAdmin) ? 'remove from admins' : 'add to admins';
  }

  async makeAdmin(item: UsersItem) {
    await this.userService.toggleUpgradeToAdmin(item.id);
    await this.refreshUserList();
  }

  async isAdmin(item: UsersItem): Promise<boolean> {
    return await this.userService.isAdmin(item.id);
  }
}
