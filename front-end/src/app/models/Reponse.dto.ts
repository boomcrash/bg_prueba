import { Producto } from './Producto.model';
import { Usuario } from './Usuario.model';

export interface ResponseDto {
  codigoRetorno?: string
  mensajeRetorno?: string
  usuario?: Usuario
  token?: string,
  data?: Producto[]
}
