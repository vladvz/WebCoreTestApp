import { Component } from "@angular/core"

@Component({
    selector: "product-list",
    templateUrl: "productList.component.html",
    styles: []
})

export class ProductList {
    public products = [
        { title: "First product", price: 19.20 },
        { title: "Second product", price: 15.44 },
        { title: "Third product", price: 9.20 }
    ];
}