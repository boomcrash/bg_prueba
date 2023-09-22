import { ProductosPlan } from './Producto.model';

export interface Retorno {
  nombre?: string;
  icono?: string;
  descripcion?: string;
  valor?: string;
  frecuencia?: string;
  codigo?: string;
  plan?: number;
  productosPlan?: ProductosPlan[],
}
