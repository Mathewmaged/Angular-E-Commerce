import { Component, OnInit } from '@angular/core';
import { Item } from '../shared/item';
import { ActivatedRoute } from '@angular/router';
import { ShopService } from '../shared/shop.service';
import { Product } from '../shared/Product.model';
import { LocalStorageService } from '../config.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  private items: Item[] = [];
	private total: number = 0;

	constructor(
		private activatedRoute: ActivatedRoute,
		private productService: ShopService,private service:LocalStorageService
	) { }
 Prouct:Product;
 pro:Product[];
 asd : any
	ngOnInit() {





    
    
		this.activatedRoute.params.subscribe(params => {
      var id = params['id'];
      console.log(typeof(id));

      this.productService.getProductByID(id).subscribe((data:Product)=>
      {this.Prouct=data;
       localStorage.setItem('cardt', JSON.stringify(data));
     });
			if (id) {
				var item: Item = {
					product:JSON.parse(localStorage.getItem('cardt')),
					quantity: 1
        };

				if (localStorage.getItem('cart') == null) {
					let cart: any = [];
					cart.push(JSON.stringify(item));
					localStorage.setItem('cart', JSON.stringify(cart));
				} else {
					let cart: any = JSON.parse(localStorage.getItem('cart'));
					let index: number = -1;
					for (var i = 0; i < cart.length; i++) {
            let item: Item = JSON.parse(cart[i]);
            console.log("i am here")
						if (item.product.ID == id) {
							index = i;
							break;
						}
					}
					if (index == -1) {
						cart.push(JSON.stringify(item));
						localStorage.setItem('cart', JSON.stringify(cart));
					} else {
						let item: Item = JSON.parse(cart[index]);
						item.quantity += 1;
						cart[index] = JSON.stringify(item);
						localStorage.setItem("cart", JSON.stringify(cart));
					}
				}
				this.loadCart();
			} else {
				this.loadCart();
			}
		});
	}

	loadCart(): void {
		this.total = 0;
		this.items = [];
		let cart = JSON.parse(localStorage.getItem('cart'));
		for (var i = 0; i < cart.length; i++) {
			let item = JSON.parse(cart[i]);
			this.items.push({
				product: item.product,
				quantity: item.quantity
			});
			this.total += item.product.Price * item.quantity;
		}
	}

	remove(id: number): void {
		let cart: any = JSON.parse(localStorage.getItem('cart'));
		let index: number = -1;
		for (var i = 0; i < cart.length; i++) {
			let item: Item = JSON.parse(cart[i]);
			if (item.product.ID == id) {
				cart.splice(i, 1);
				break;
			}
		}
    localStorage.setItem("cart", JSON.stringify(cart));
    localStorage.setItem("cardt", '');

		this.loadCart();
	}


}
