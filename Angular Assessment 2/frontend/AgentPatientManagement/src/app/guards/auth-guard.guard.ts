import { CanActivateFn, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { inject, Inject } from '@angular/core';
import { UtilsService } from '../services/utils/session';

export const authGuardGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
  const router: Router = inject(Router)
  const session = inject(UtilsService)
  // const isSessionActive: boolean = session.getSession()
  let isSessionActive: boolean = false
  if (localStorage.getItem("session") == "true"){
    isSessionActive = true;
  }
  const protectedRoutes: string[] = ["/profile", "/profile/change-password"];
  return protectedRoutes.includes(state.url) && isSessionActive ? true : router.navigate(["/"]);
};
