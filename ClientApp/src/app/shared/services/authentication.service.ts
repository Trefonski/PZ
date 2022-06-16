import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EnvironmentUrlService } from './environment-url.service';
import { Subject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserForRegistration } from 'src/app/interfaces/userForRegistration.interface';
import { UserForAuthentication } from 'src/app/interfaces/userForAuthentication.interface';
import { AuthResponse } from 'src/app/interfaces/authResponse.interface';
import { RegistrationResponse } from 'src/app/interfaces/registrationResponse.interface';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private authChangeSub = new Subject<boolean>()
  public authChanged = this.authChangeSub.asObservable();

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService, private jwtHelper: JwtHelperService) { }

  public registerUser = (route: string, body: UserForRegistration) => {
    return this.http.post<RegistrationResponse> (this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }

  public loginUser = (route: string, body: UserForAuthentication) => {
    return this.http.post<AuthResponse>(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this.authChangeSub.next(isAuthenticated);
  }

  public logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }

  public isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("token");
 
    return (token && !this.jwtHelper.isTokenExpired(token)) as boolean;
  }

  public isUserAdmin = (): boolean => {
    const token = localStorage.getItem("token") || '';
    const decodedToken = this.jwtHelper.decodeToken(token);
    const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

    return role === 'Administrator';
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}