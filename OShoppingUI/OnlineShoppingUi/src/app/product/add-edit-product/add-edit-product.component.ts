import { Component,OnInit,Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-product',
  templateUrl: './add-edit-product.component.html',
  styleUrls: ['./add-edit-product.component.css']
})
export class AddEditProductComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() product:any;
  ProductId: string | undefined;
  ProductName:string | undefined;

  ngOnInit(): void {
    this.ProductId=this.product.ProductId;
    this.ProductName=this.product.ProductName
  }

  addProduct(){
    var val = {ProductId:this.ProductId,
      ProductName:this.ProductName};
    this.service.addProduct(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateProduct(){
    var val = {ProductId:this.ProductId,
      ProductName:this.ProductName};
    this.service.updateProduct(val).subscribe(res=>{
    alert(res.toString());
    });
  }

}
