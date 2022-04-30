import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Truck } from 'src/app/shared/truck.model';
import { TruckService } from 'src/app/shared/truck.service';

@Component({
  selector: 'app-truck-form',
  templateUrl: './truck-form.component.html',
  styles: [
  ]
})
export class TruckFormComponent implements OnInit {

  modelos = [{ id: "", name: "Selecione um modelo" }, { id: "FM", name: "FM" }, { id: "FD", name: "FD" }];

  constructor(public service: TruckService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    this.service.postTruck().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Salvo com sucesso', 'Caminhão');
        this.service.refreshList();
      },
      err => {
        console.log(err)
      }
    );

  }

  resetForm(form: NgForm) {
    this.service.formData = new Truck();
  }
}
