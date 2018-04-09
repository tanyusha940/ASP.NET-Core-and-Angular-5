import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UsersItem } from '@app/admin-page/admin/models/userItem';
import { ToastsManager } from 'ng2-toastr';

@Injectable()
export class UsersService {
    constructor(private httpClient: HttpClient,
                private toastr: ToastsManager) { }

    async getUsers(): Promise<UsersItem[]> {
        return await this.httpClient
        .get<UsersItem[]>('/user').toPromise();
    }

    async toggleBlockUser(id: string) {
        await this.httpClient
            .post<boolean>('/adminPanel/block', {userId: id}).toPromise()
            .then(() => {
                this.toastr.success('Action Successfull', 'Success!');
              });
    }
}
