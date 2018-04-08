import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { map, catchError } from 'rxjs/operators';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { Conspect } from '@app/personal-page/conspect-form/models/conspect';
import { ConspectItem } from '@app/shared/consectItem/models/conspectItem';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { LookUp } from '@app/personal-page/conspect-form/models/lookUp';


@Injectable()
export class ConspectsService {

  constructor(private httpClient: HttpClient,
              private toastr: ToastsManager) { }

  async getConspects(): Promise<ConspectItem[]> {
      return await this.httpClient
      .get<ConspectItem[]>('/conspect').toPromise();
  }

  async createConspect(conspect: Conspect, tags: LookUp[]) {
    await this.httpClient
      .post<number>('/conspect', {conspect: conspect, tags: tags})
      .toPromise()
      .then(() => {
        this.toastr.success('Conspect created', 'Success!');
      });
  }

  async deleteConspect(id: number): Promise<{}> {
    return await this.httpClient
      .delete(`/conspect/${id}`).toPromise();
  }
  async updateConspect(conspect: Conspect): Promise<Conspect> {
    return await this.httpClient
      .put<Conspect>('/conspect', conspect)
      .toPromise();
  }

  async GetSortByDateConspects(): Promise<ConspectItem[]> {
    return await this.httpClient
    .get<ConspectItem[]>('/SortConspectController/GetSortByDateConspects').toPromise();
  }

  async GetSortByRatingConspects(): Promise<ConspectItem[]> {
    return await this.httpClient
    .get<ConspectItem[]>('/SortConspectController/GetSortByRatingConspects').toPromise();
  }
}
