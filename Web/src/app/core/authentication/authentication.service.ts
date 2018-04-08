import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient } from '@angular/common/http';
import { NgxPermissionsService } from 'ngx-permissions';

export interface Credentials {
  // Customize received credentials here
  id: string;
  token: string;
  username: string;
  role: string;
  isEmailConfirmed: boolean;
}

export interface LoginContext {
  username: string;
  password: string;
  remember?: boolean;
}

const credentialsKey = 'credentials';

/**
 * Provides a base for authentication workflow.
 * The Credentials interface as well as login/logout methods should be replaced with proper implementation.
 */
@Injectable()
export class AuthenticationService {

  private _credentials: Credentials | null;

  constructor(private http: HttpClient,
              private permissionsService: NgxPermissionsService) {
    const savedCredentials = sessionStorage.getItem(credentialsKey) || localStorage.getItem(credentialsKey);
    if (savedCredentials) {
      this._credentials = JSON.parse(savedCredentials);
    }
  }

  /**
   * Authenticates the user.
   * @param {LoginContext} context The login parameters.
   * @return {Observable<Credentials>} The user credentials.
   */
  async login(context: LoginContext): Promise<boolean | string> {
    const result = await this.http
    .post<Credentials>('/login', context)
    .toPromise()
    .then((data: Credentials) => {
      if (data.isEmailConfirmed) {
        this.setCredentials(data, context.remember);
        return true;
      }

      return 'confirm your email';
    })
    .catch((data) => 'invalid login or password');

    return result;
  }

  /**
   * Logs out the user and clear credentials.
   * @return {Observable<boolean>} True if the user was logged out successfully.
   */
  logout(): Observable<boolean> {
    // Customize credentials invalidation here
    this.setCredentials();
    return of(true);
  }

  /**
   * Checks is the user is authenticated.
   * @return {boolean} True if the user is authenticated.
   */
  isAuthenticated(): boolean {
    return !!this.credentials;
  }

  /**
   * Gets the user credentials.
   * @return {Credentials} The user credentials or null if the user is not authenticated.
   */
  get credentials(): Credentials | null {
    return this._credentials;
  }

  get username(): string | null {
    return this.credentials ? this.credentials.username : null;
  }

  /**
   * Sets the user credentials.
   * The credentials may be persisted across sessions by setting the `remember` parameter to true.
   * Otherwise, the credentials are only persisted for the current session.
   * @param {Credentials=} credentials The user credentials.
   * @param {boolean=} remember True to remember credentials across sessions.
   */
  private setCredentials(credentials?: Credentials, remember?: boolean) {

    this._credentials = credentials || null;
    this.permissionsService.flushPermissions();
    if (this._credentials && this._credentials.role) {
      this.permissionsService.addPermission(this._credentials.role);
    }

    this.permissionsService.addPermission('guest');
    if (credentials) {
      const storage = remember ? localStorage : sessionStorage;
      storage.setItem(credentialsKey, JSON.stringify(credentials));
    } else {
      sessionStorage.removeItem(credentialsKey);
      localStorage.removeItem(credentialsKey);
    }
  }

  defineDefaultRoles() {
    this.permissionsService.addPermission('guest');
  }

}
