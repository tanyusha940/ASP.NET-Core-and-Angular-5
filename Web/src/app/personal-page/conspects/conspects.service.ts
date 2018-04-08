import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { map, catchError } from 'rxjs/operators';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { Conspect } from '@app/personal-page/conspect-form/models/conspect';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { LookUp } from '@app/personal-page/conspect-form/models/lookUp';


@Injectable()
export class ConspectsService {

  constructor(private httpClient: HttpClient,
              private toastr: ToastsManager) { }

  async getConspects(url: string = '/conspect'): Promise<Conspect[]> {
      return await this.httpClient
      .get<Conspect[]>(url).toPromise();
  }

  async createConspect(conspect: Conspect, tags: LookUp[]) {
    await this.httpClient
      .post<number>('/conspect', {conspect: conspect, tags: tags})
      .toPromise()
      .then(() => {
        this.toastr.success('Conspect created', 'Success!');
      });
  }

  async getById(id: number): Promise<Conspect> {
    return await this.httpClient
      .get<Conspect>(`/conspect/${id}`)
      .toPromise();
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

  async GetSortByDateConspects(): Promise<Conspect[]> {
    return await this.httpClient
    .get<Conspect[]>('/SortConspectController/GetSortByDateConspects').toPromise();
  }

  async GetSortByRatingConspects(): Promise<Conspect[]> {
    return await this.httpClient
    .get<Conspect[]>('/SortConspectController/GetSortByRatingConspects').toPromise();
  }
}
