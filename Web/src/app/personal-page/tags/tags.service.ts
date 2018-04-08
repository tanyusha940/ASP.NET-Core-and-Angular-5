import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TagItem } from '@app/personal-page/tags/models/tagItem';
import { LookUp } from '@app/personal-page/conspect-form/models/lookUp';


@Injectable()
export class TagsService {
    constructor(private httpClient: HttpClient) { }

    async getTags(): Promise<LookUp[]> {
        return await this.httpClient
        .get<LookUp[]>('/lookUp/tags').toPromise();
    }

    async getConspectTags(id: number): Promise<LookUp[]> {
        return await this.httpClient
        .get<LookUp[]>(`/lookUp/tags/${id}`).toPromise();
    }
}
