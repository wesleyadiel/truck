import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Truck } from './truck.model';
import { Response } from './response.model';

@Injectable({
  providedIn: 'root'
})
export class TruckService {

  constructor(private http: HttpClient) { }

  readonly _url = "https://localhost:44385/api/Caminhao";
  formData: Truck = new Truck();
  list: Truck[] = [];

  postTruck() {
    return this.http.post(this._url, this.formData);
  }

  refreshList() {
    this.http.get(this._url).toPromise().then(res => {
      this.list = (res as Response).data as Truck[];
    });
  }

  deleteTruck(id: Number) {
    return this.http.delete(this._url + '/' + id);
  }
}
