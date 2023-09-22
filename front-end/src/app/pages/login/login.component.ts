import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BodyDto } from '../../models/BodyDto.model';
import { ToastrService } from 'ngx-toastr';
import { ResponseDto } from 'src/app/models/Reponse.dto';
import { Usuario } from 'src/app/models/Usuario.model';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  form!: FormGroup;
  usuario?: Usuario;

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private _loginService: LoginService,
    private router: Router
  ) {}

  ngOnInit() {
    this.form = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login() {
    if (this.form.valid) {
      let loginData: BodyDto = {
        transaccion: 'autenticarUsuario',
        datosUsuario: {
          email: this.form.value.email,
          password: this.form.value.password,
        },
      };
      this._loginService.login(loginData).subscribe({
        next: (resp: ResponseDto) => {
          if (resp.codigoRetorno == '0001') {
            this.router.navigate(['/productos']);
            this.usuario = resp.usuario;
            this.toastr.success('Bienvenido', resp.mensajeRetorno);
            localStorage.setItem('logged', 'true');
          } else {
            this.toastr.error(
              'Credenciales incorrectas',
              'Error al inciar sesión'
            );
          }
        },
        error: (err) => {
          this.toastr.error('Algó salió mal', 'Error');
        },
      });
    } else {
      this.toastr.error('Debe ingresar usuario y contraseña', 'Error');
    }
  }
}
