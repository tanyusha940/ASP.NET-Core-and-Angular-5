import { Injectable } from '@angular/core';
import { RatingItem } from '@app/shared/rating/models/ratingsItem';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class RatingsService {
    constructor(private httpClient: HttpClient) { }

    async getRating(id: number): Promise<number> {
        return await this.httpClient
        .get<number>(`/Rating/calculateRating/${id}`).toPromise();
    }
}
