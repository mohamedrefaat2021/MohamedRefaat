import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { OrderService } from '../order.service';
import { Order } from '../order';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource, } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { SelectionModel } from '@angular/cdk/collections';




@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})

export class OrderComponent implements OnInit {
  dataSaved = false;
  productForm: any;
  allOrders: Observable<Order[]>;
  dataSource: MatTableDataSource<Order>;
  testRes!: any;
  selection = new SelectionModel<Order>(true, []);
  productIdUpdate = null;
  massage = null;
  

  horizontalPosition: MatSnackBarHorizontalPosition = 'center';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  displayedColumns: string[] = [ 'OrderId','Quantity','Price','OrderDate','ProductName'];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private formbulider: FormBuilder, private orderService: OrderService, private _snackBar: MatSnackBar, public dialog: MatDialog) {
  
  }

  ngOnInit() {
    
    this.GetAllProduct();
   
  }
   GetAllProduct()
   {

    this.orderService.getAllOrder().subscribe(data => {
  this.testRes = data['data']['results']
console.log("1111111", this.testRes);

   
      this.dataSource = this.testRes
      console.log("qqqqqq", this.dataSource);
      
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
   }

}

