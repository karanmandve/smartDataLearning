import { inject } from '@angular/core';
import { CanActivateFn, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

export const authGuardGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
  const router = inject(Router);
  
  const isSessionActive = localStorage.getItem("session") === "true";
  const protectedRoutes = ["/home", "/profile", "/cart", "/orders"];
  
  if (protectedRoutes.includes(state.url) && isSessionActive) {
    return true;
  } else {
    router.navigate(["/"]);
    return false;
  }
};