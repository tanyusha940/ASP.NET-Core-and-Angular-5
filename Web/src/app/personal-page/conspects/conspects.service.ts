import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { map, catchError } from 'rxjs/operators';
import { ConspectItem } from '@app/personal-page/conspects/models/conspectItem';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Injectable()
export class ConspectsService {

  constructor(private httpClient: HttpClient) { }

  async getConspects(): Promise<ConspectItem[]> {
      return await this.httpClient
      .get<ConspectItem[]>('/conspect').toPromise();
  }

}