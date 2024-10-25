import { CanActivateFn, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { inject, Inject } from '@angular/core';
import { UtilsService } from '../services/utils/session';

export const authGuardGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
  const router: Router = inject(Router)
  const session = inject(UtilsService)
  const isSessionActive: boolean = session.getSession()
  const protectedRoutes: string[] = ["/profile"];
  return protectedRoutes.includes(state.url) && !isSessionActive ? router.navigate(["/"]) : true;
};
