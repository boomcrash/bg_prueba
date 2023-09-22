import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BodyDto } from '../models/BodyDto.model';
import { ResponseDto } from '../models/Reponse.dto';
import { environments } from '../../environments/environment.development';

const apiUrl = environments.apiUrl;

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private http: HttpClient) {}

  login(login: BodyDto) {
    return this.http.post<ResponseDto>(`${apiUrl}/usuarios`, login);
  }
}
