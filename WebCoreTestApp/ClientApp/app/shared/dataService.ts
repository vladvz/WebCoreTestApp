import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Product } from "./product";
import { Order, OrderItem } from "./order";
import "rxjs/add/operator/map";

@Injectable()
export class DataService {
    constructor(private http: HttpClient) {

    };

    public products: Product[] = [];
    public order: Order = new Order();

    loadProducts(): Observable<boolean> {
        return this.http.get("/api/products")
            .map((data: any[]) => {
                this.products = data;
                return true;
            });
    };

    public AddToOrder(product: Product){
        let item: OrderItem = this.order.items.find(i => i.productId == product.id);

        if (item) {
            item.quantity++;
        } else {
            item = new OrderItem();
            item.productId = product.id;
            item.productArtist = product.artist;
            item.productCategory = product.category;
            item.productArtId = product.artId;
            item.productTitle = product.title;
            item.unitPrice = product.price;
            item.quantity = 1;

            this.order.items.push(item);
        }
    }
}