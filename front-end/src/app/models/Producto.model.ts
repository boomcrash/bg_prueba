export interface Producto {
  id?: string;
  descripcion?: string;
  precio?: string;
  estado?: boolean;
  detalle?: string;
  imagen?: string;
}

export interface ProductosPlan {
  producto: string;
  descripcion: string;
  cantidad: number;
}
