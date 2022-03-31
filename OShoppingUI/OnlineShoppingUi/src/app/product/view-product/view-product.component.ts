import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {

  constructor(private service:SharedService) { }

  ProductList : any=[];

  ModalTitle:string | undefined;
  ActivateAddEditProductComponent:boolean=false;
  product:any;

  ProductIdFilter:string="";
  ProductNameFilter:string="";
  ProductListWithoutFilter:any=[];


  ngOnInit(): void {
    this.refreshProductList();
  }

  addClick(){
    this.product={
      ProductId:0,
      ProductName:""
    }
    this.ModalTitle="Add Product";
    this.ActivateAddEditProductComponent=true;

  }

  editClick(item: any){
    this.product=item;
    this.ModalTitle="Edit Product";
    this.ActivateAddEditProductComponent=true;
  }

  deleteClick(item: { ProductId: any; }){
    if(confirm('Are you sure??')){
      this.service.deleteProduct(item.ProductId).subscribe(data=>{
        alert(data.toString());
        this.refreshProductList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditProductComponent=false;
    this.refreshProductList();
  }


  refreshProductList(){
    this.service.getProductList().subscribe(data=>{
      this.ProductList=data;
      this.ProductListWithoutFilter=data;
    });
  }




}
