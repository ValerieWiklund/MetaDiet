import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Login from "./views/Login.vue";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import Profile from "./views/Profile.vue";

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
