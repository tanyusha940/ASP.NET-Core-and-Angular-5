import { Component, OnInit } from '@angular/core';
import { UsersItem } from '@app/admin-page/admin/models/userItem';
import { UsersService } from '@app/admin-page/admin/users.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  userItem: UsersItem[];
  constructor(
    private userService: UsersService
  ) { }

  async ngOnInit() {
    this.userItem = await this.userService.getUsers();
  }

}
