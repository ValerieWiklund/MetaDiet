import Vue from "vue";
import Router from "vue-router";

// @ts-ignore
Vue.use(Router);

// @ts-ignore
export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      // @ts-ignore
      component: Home
    },
    {
      path: "/login",
      name: "login",
      // @ts-ignore
      component: Login
    },
    {
      path: "/profile/userId",
      name: "profile",
      // @ts-ignore
      component: Profile
    }
  ]
});
