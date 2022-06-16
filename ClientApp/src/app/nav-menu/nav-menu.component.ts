import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../shared/services/authentication.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  public isUserAuthenticated: boolean = false;
  isExpanded = false;

  constructor(private authService: AuthenticationService,private router: Router) { }

  ngOnInit(): void {
    this.authService.authChanged.subscribe(res => {
      console.log(res);
      this.isUserAuthenticated = res;
    })
  }

  collapse() {
    this.isExpanded = false;
  }

  logout = () => {
    this.authService.logout();
    this.router.navigate(["/"]);
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
