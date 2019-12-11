import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    foods: [],
    activeFood: {},
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setFoods(state, data) {
      state.foods = data
    },

    setActiveFood(state, data) {
      state.activeFood = data
    },



  },
  actions: {
    //#region -- AUTHORIZATION/USER  --
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },

    async editProfile({ dispatch }, data) {
      try {
        let res = await api.put(`account/${data.userid}`, data)
        dispatch("getFoodById", data.id)
      } catch (error) {
        console.error(error)
      }
    },

    //#endregion

    //#region -- KEEPS --
    async getFoods({ commit, dispatch }) {
      try {
        let res = await api.get('foods')
        commit('setFoods', res.data)
      } catch (error) {
        console.error(error)
      }
    },

    async getFoodById({ commit }, data) {
      try {
        let res = await api.get(`foods/${data}`)
        commit('setActiveFood', res.data)
      } catch (error) {
        console.error(error)

      }
    },
    async getFoodsByCategory({ commit, dispatch }) {
      try {
        let res = await api.get('keeps/category')
        commit('setFoods', res.data)
      } catch (error) {
        console.error(error)
      }
    },


    async addFood({ dispatch }, data) {
      try {
        let res = await api.post('foods', data)
        // dispatch('getKeepsByUser')
      } catch (error) {
        console.error(error)
      }
    },

    async editFood({ dispatch }, data) {
      try {
        let res = await api.put(`foods/${data.id}/view`, data)
        dispatch("getFoodById", data.id)
      } catch (error) {
        console.error(error)
      }
    },

    async deleteFood({ dispatch }, data) {
      try {
        let res = await api.delete(`foods/${data}`)
        // dispatch('getKeepsByUser')
      } catch (error) {
        console.error(error)
      }
    },


    //#endregion


    ////#endregion
  }
})
