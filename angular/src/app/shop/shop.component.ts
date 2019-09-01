import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shared/shop.service';
import { Product } from '../shared/Product.model';
import { Category } from '../shared/Category.model';
@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  prdLists: Product[];
  Category:Category[];
  
  constructor(private prd:ShopService) { }

  ngOnInit() {
    this.prd.getAllProductss()
    .subscribe((data) => {
      this.prdLists = data;
    },
    (err) => {
      console.log(err);
    });
   
    this.get();
    this.prd.getAllCategory()
    .subscribe((data) => {
      this.Category = data;
    },
    (err) => {
      console.log(err);
    });
  }
  get(){
   var time={name:"sdkjakd",id:"akd"};
   
  }



}
