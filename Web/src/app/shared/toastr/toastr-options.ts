import { Component, Injectable } from '@angular/core';
import {ToastOptions} from 'ng2-toastr';

@Injectable()
export class CustomToastrOptions extends ToastOptions {
  newestOnTop = true;
  positionClass = 'toast-bottom-right';
}
