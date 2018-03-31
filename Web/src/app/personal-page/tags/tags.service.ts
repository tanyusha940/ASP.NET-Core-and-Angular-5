import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { TagItem } from "@app/personal-page/tags/models/tagItem";


@Injectable()
export class TagsService{
    constructor(private httpClient: HttpClient){ }

    async getTags(): Promise<TagItem[]>{
        return await this.httpClient
        .get<TagItem[]>('/Tag').toPromise();
    }
}