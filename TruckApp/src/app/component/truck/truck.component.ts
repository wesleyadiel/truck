import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Truck } from 'src/app/shared/truck.model';
import { TruckService } from 'src/app/shared/truck.service';

@Component({
  selector: 'app-truck',
  templateUrl: './truck.component.html',
  styles: [
  ]
})
export class TruckComponent implements OnInit {

  constructor(public service: TruckService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  deleteTruck(id: number) {
    if (confirm('Tem certeza que deseja excluir esse caminhão?')) {
      this.service.deleteTruck(id).subscribe(res => {
        this.toastr.success('Caminhão excluído com sucesso', 'Caminhão');
        this.service.refreshList();
      }, err => {
        this.toastr.error('Ocorreu um erro ao excluir caminhão', 'Caminhão');
      });
    }
  }

  editForm(c: Truck) {
    this.service.formData = Object.assign({}, c);
  }

}
