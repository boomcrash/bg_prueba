import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Producto } from 'src/app/models/Producto.model';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent {
  productos?: Producto[] = [
    {
      descripcion: 'Producto 1',
      detalle: 'Detalle del producto 1',
      estado: true,
      imagen: 'https://picsum.photos/200/300',
      precio: "1000"    
    },
    {
      descripcion: 'Producto 1',
      detalle: 'Detalle del producto 1',
      estado: true,
      imagen: 'https://picsum.photos/200/300',
      precio: "1000"    
    },
    {
      descripcion: 'Producto 1',
      detalle: 'Detalle del producto 1',
      estado: true,
      imagen: 'https://picsum.photos/200/300',
      precio: "1000"    
    },
    {
      descripcion: 'Producto 1',
      detalle: 'Detalle del producto 1',
      estado: true,
      imagen: 'https://picsum.photos/200/300',
      precio: "1000"    
    },
  ];

  constructor(
    private toastr: ToastrService,
    private router: Router,
    private _productoService: ProductoService
  ) {}

  

}
