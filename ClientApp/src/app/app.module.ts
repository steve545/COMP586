import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Router } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';
import { AuthorWithBooksComponent } from './author-with-books/author-with-books.component';
import { AuthorsComponent } from './authors/authors.component';
import { BooksComponent } from './books/books.component';
import { OKTA_CONFIG } from '@okta/okta-angular';
import { OktaAuthModule } from '@okta/okta-angular';
import { OktaCallbackComponent } from '@okta/okta-angular';
import { OktaAuthGuard } from '@okta/okta-angular';
import { ProfileComponent } from './profile/profile.component';
import { OktaLoginRedirectComponent } from '@okta/okta-angular';
import { LoginComponent } from './login/login.component';

const config = {
  issuer: 'https://dev-3701272.okta.com/oauth2/default',
  redirectUri: window.location.origin + '/login/callback',
  clientId: '0oa28niz2SIMsPEzT5d6',
  pkce: true
}

export function onAuthRequired(oktaAuth, injector) {
  const router = injector.get(Router);

  // Redirect the user to your custom login page
  router.navigate(['/login']);
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CounterComponent,
    FetchDataComponent,
    HomeComponent,
    AuthorWithBooksComponent,
    AuthorsComponent,
    BooksComponent,
    ProfileComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    OktaAuthModule,
    RouterModule.forRoot([
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'author-with-books/:id', component: AuthorWithBooksComponent },
      { path: 'authors', component: AuthorsComponent },
      { path: 'login', component: LoginComponent },
      {
        path: 'books', component: BooksComponent, canActivate: [OktaAuthGuard], data: {
          onAuthRequired
        }
      },
      { path: 'login/callback', component: OktaCallbackComponent }
    ])
  ],
  providers: [
    {
      provide: OKTA_CONFIG, useValue: config
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
