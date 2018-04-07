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
    this.userItem = await this.userService.getUsers();
  }
  createAdmin(){

  }
  blockUser(){

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
}
