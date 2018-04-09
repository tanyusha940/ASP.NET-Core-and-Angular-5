import { LookUp } from '@app/personal-page/conspect-form/models/lookUp';

export class Conspect {
    public name: string;
    public specialityNumberId: number;
    public content: string;
    public id: number;
    public createdDate: Date;
    public userName: string;
    public tags: LookUp[];
}
