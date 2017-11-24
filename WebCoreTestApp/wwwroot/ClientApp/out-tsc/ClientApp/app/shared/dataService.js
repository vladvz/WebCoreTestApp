"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/common/http");
var core_1 = require("@angular/core");
var order_1 = require("./order");
require("rxjs/add/operator/map");
var DataService = (function () {
    function DataService(http) {
        this.http = http;
        this.products = [];
        this.order = new order_1.Order();
    }
    ;
    DataService.prototype.loadProducts = function () {
        var _this = this;
        return this.http.get("/api/products")
            .map(function (data) {
            _this.products = data;
            return true;
        });
    };
    ;
    DataService.prototype.AddToOrder = function (product) {
        var item;
        item = new order_1.OrderItem();
        item.productId = product.id;
        item.productArtist = product.artist;
        item.productCategory = product.category;
        item.productArtId = product.artId;
        item.unitPrice = product.price;
        item.quantity = 1;
        this.order.items.push(item);
    };
    return DataService;
}());
DataService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.HttpClient])
], DataService);
exports.DataService = DataService;
//# sourceMappingURL=dataService.js.map