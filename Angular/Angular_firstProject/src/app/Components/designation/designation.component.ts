import { Component, inject, OnInit } from '@angular/core';
import { MasterService } from '../../services/master.service';
import { IDepartment } from '../../Model/interface/department';

@Component({
  selector: 'app-designation',
  standalone: true,
  imports: [],
  templateUrl: './designation.component.html',
  styleUrl: './designation.component.css',
})
export class DesignationComponent implements OnInit {
  
  allDepartmentList: IDepartment [] = [];
  
  masterService = inject(MasterService);



  ngOnInit(): void {

    this.masterService.getAllDepartments().subscribe((res: any) => {
      this.allDepartmentList = res;
    }, error => {
      alert("API Error / Network Down");
    })

  }
}
