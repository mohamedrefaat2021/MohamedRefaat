import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { ProductService } from '../product.service';
import { Product } from '../product';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource, } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { SelectionModel } from '@angular/cdk/collections';




@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent implements OnInit {
  dataSaved = false;
  productForm: any;
  allProducts: Observable<Product[]>;
  dataSource: MatTableDataSource<Product>;
  testRes!: any;
  selection = new SelectionModel<Product>(true, []);
  productIdUpdate = null;
  massage = null;
  

  horizontalPosition: MatSnackBarHorizontalPosition = 'center';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  displayedColumns: string[] = ['select', 'ProductName','SupplierName','Quantity','Description','Notes', 'Edit','Delete'];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private formbulider: FormBuilder, private productService: ProductService, private _snackBar: MatSnackBar, public dialog: MatDialog) {
  
  }

  ngOnInit() {
    this.productForm = this.formbulider.group({
      Id :[],
      ProductName: ['', [Validators.required]],
      SupplierName: ['', [Validators.required]],
      Quantity: ['', [Validators.required]],
      Description: [''],
      Notes: ['']
    
    });
    this.GetAllProduct();
    
  }
   GetAllProduct()
   {

    this.productService.getAllProduct().subscribe(data => {
  this.testRes = data['data']['results']
console.log("1111111", this.testRes);

   
      this.dataSource = this.testRes
      console.log("qqqqqq", this.dataSource);
      
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
   }


  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = !!this.dataSource && this.dataSource.data.length;
    return numSelected === numRows;
  }

 /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ? this.selection.clear() : this.dataSource.data.forEach(r => this.selection.select(r));
  }
  /** The label for the checkbox on the passed row */
  checkboxLabel(row: Product): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id + 1}`;
  }
  
  DeleteData() {
    debugger;
    const numSelected = this.selection.selected;
    if (numSelected.length > 0) {
      if (confirm("Are you sure to delete items ")) {
        this.productService.deleteData(numSelected).subscribe(result => {
          this.SavedSuccessful(2);
          this.loadAllProducts();
        })
      }
    } else {
      alert("Select at least one row");
    }
  }

  loadAllProducts() {
    this.productService.getAllProduct().subscribe(data => {
      this.dataSource = new MatTableDataSource(data);
      //this.dataSource.paginator = this.paginator;
      //this.dataSource.sort = this.sort;
    });
  }
  onFormSubmit() {
    this.dataSaved = false;
    const product = this.productForm.value;
    this.CreateProduct();
    this.productForm.reset();
  }

  loadProductToEdit(Product: any) {
   
    
    
    this.productService.getProducBytId(Product.id).subscribe(product => {  
      
      this.massage = null;
      this.dataSaved = false;
      this.productIdUpdate = 1;
      this.productForm.controls['ProductName'].setValue(Product.productName);
      this.productForm.controls['SupplierName'].setValue(Product.supplierName);
      this.productForm.controls['Quantity'].setValue(Product.quantity);
      this.productForm.controls['Description'].setValue(Product.description);
      this.productForm.controls['Notes'].setValue(Product.notes);
       this.productForm.controls['Id'].setValue(Product.id);
      
    });

  }
  CreateProduct() {
    const formdata =this.productForm.value;
     
    if (this.productIdUpdate == null) {
    delete formdata.Id;
     console.log("Test",formdata)
      this.productService.createProduct(formdata).subscribe(
        () => {
          this.dataSaved = true;
          this.SavedSuccessful(1);         
          this.productIdUpdate = null;
          this.productForm.reset();
          this.GetAllProduct();
        }
      );
     
    } else {
    
      console.log("Result",formdata);
      this.productService.updateProduct(formdata).subscribe(() => {
        
        this.dataSaved = true;
        this.SavedSuccessful(0);
        this.GetAllProduct();
        this.productIdUpdate = null;
        this.productForm.reset();
      });
    }
  }
  deleteProduct(Product:any) {
    console.log("/Delete",Product.id)
    if (confirm("Are you sure you want to delete this ?")) {
      this.productService.deleteProductById(Product.id).subscribe(() => {
        this.dataSaved = true;
        this.SavedSuccessful(2);
        
        this.productIdUpdate = null;
        
        this.GetAllProduct();
      });
    }

  }

 

  resetForm() {
    this.productForm.reset();
    this.massage = null;
    this.dataSaved = false;
    this.loadAllProducts();
  }

  SavedSuccessful(isUpdate) {
    if (isUpdate == 0) {
      this._snackBar.open('Record Updated Successfully!', 'Close', {
        duration: 2000,
        horizontalPosition: this.horizontalPosition,
        verticalPosition: this.verticalPosition,
      });
    } 
    else if (isUpdate == 1) {
      this._snackBar.open('Record Saved Successfully!', 'Close', {
        duration: 2000,
        horizontalPosition: this.horizontalPosition,
        verticalPosition: this.verticalPosition,
      });
    }
    else if (isUpdate == 2) {
      this._snackBar.open('Record Deleted Successfully!', 'Close', {
        duration: 2000,
        horizontalPosition: this.horizontalPosition,
        verticalPosition: this.verticalPosition,
      });
    }
  }
}
