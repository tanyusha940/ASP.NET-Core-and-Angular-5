import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { UsersItem } from "@app/admin-page/admin/models/userItem";

@Injectable()
export class UsersService{
    constructor(private httpClient: HttpClient) { }

    async getUsers(): Promise<UsersItem[]>{
        return await this.httpClient
        .get<UsersItem[]>('/user').toPromise();
    }
}