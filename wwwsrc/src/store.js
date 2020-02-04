import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import AuthService from "./AuthService";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    user: {},
    profile: {},
    foods: [],
    ActiveFood: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user;
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {};
    },
    setProfile(state, data) {
      state.profile = data;
    },
    setFoods(state, data) {
      state.foods = data;
    },
    setActiveFood(state, data) {
      state.ActiveFood = data;
    }
  },
  actions: {
    //#region -- AUTHORIZATION/USER  --
    async register({ commit, dispatch }, creds) {
      try {
        debugger;
        let user = await AuthService.Register(creds);
        commit("setUser", user);
        router.push({ name: "home" });
      } catch (e) {
        console.warn(e.message);
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds);
        commit("setUser", user);
        router.push({ name: "home" });
      } catch (e) {
        console.warn(e.message);
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout();
        if (!success) {
        }
        commit("resetState");
        router.push({ name: "home" });
      } catch (e) {
        console.warn(e.message);
      }
    },
    //#endregion

    //#region -- PROFILE --
    async getProfileByUser({ commit }) {
      try {
        let res = await api.get("profile/user");
        commit("setProfile", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getProfileById({ commit }, data) {
      try {
        let res = await api.get(`profiles/${data}`);
        commit("setProfile", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async addProfile({ dispatch }, data) {
      try {
        let res = await api.post("profiles", data);
        dispatch("getProfileByUser");
      } catch (error) {
        console.error(error);
      }
    },
    async editProfile({ dispatch }, data) {
      try {
        let res = await api.put(`profiles/${data.id}`, data);
        dispatch("getProfileById", data.id);
      } catch (error) {
        console.error(error);
      }
    },
    async deleteProfile({ dispatch }, data) {
      try {
        let res = await api.delete(`profiles/${data.id}`, data);
      } catch (error) {
        console.error(error);
      }
    }

    //#endregion
  }
});
