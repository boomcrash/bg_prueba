import { Usuario } from "./Usuario.model";

export interface BodyDto {
    transaccion: string,
    datosUsuario?: Usuario,
    tipo?: string,
    
}