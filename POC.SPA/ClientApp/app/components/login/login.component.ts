
import { Component } from '@angular/core';
import { User } from '../../../shared/user.type';
import { Router } from '@angular/router';
@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})
export class LoginComponent {
    
    user: User;
    IsUserValid: boolean;

    constructor(private router:Router)
    {
        //this.name = 'Sam';

        this.user = new User();
        this.IsUserValid = true;
    }

    loginClicked()
    {
        this.IsUserValid = true;
        if (this.user.username == "demo3" && this.user.password == "demo3") {
            alert('true');
            this.router.navigate(["dashboard"]);
        }
        else {

            this.IsUserValid = false;
        }
    }
}

