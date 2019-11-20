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
    keeps: [],
    activeKeep: {},
    vaults: [],
    activeVault: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeeps(state, data) {
      state.keeps = data
    },

    setActiveKeep(state, data) {
      state.activeKeep = data
    },

    setVaults(state, data) {
      state.vaults = data
    },

    setActiveVault(state, data) {
      state.activeVault = data
    }

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

    //#endregion

    //#region -- KEEPS --
    async getKeeps({ commit, dispatch }) {
      try {
        let res = await api.get('keeps')
        commit('setKeeps', res.data)
      } catch (error) {
        console.error(error)
      }
    },

    async getKeepById({ commit }, data) {
      try {
        let res = await api.get(`keeps/${data}`)
        commit('setActiveKeep', res.data)
      } catch (error) {
        console.error(error)

      }
    },
    async getKeepsByUser({ commit, dispatch }) {
      try {
        let res = await api.get('keeps/user')
        commit('setKeeps', res.data)
      } catch (error) {
        console.error(error)
      }
    },


    async addKeep({ dispatch }, data) {
      try {
        let res = await api.post('keeps', data)
        dispatch('getKeepsByUser')
      } catch (error) {
        console.error(error)
      }
    },

    async editKeep({ dispatch }, data) {
      try {
        let res = await api.put(`keeps/${data.id}/view`, data)
        dispatch("getKeepById", data.id)
      } catch (error) {
        console.error(error)
      }
    },

    async deleteKeep({ dispatch }, data) {
      try {
        let res = await api.delete(`keeps/${data}`)
        dispatch('getKeepsByUser')
      } catch (error) {
        console.error(error)
      }
    },


    //#endregion

    //#region -- VAULTS --
    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get('vaults')
        commit('setVaults', res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async addVault({ dispatch }, data) {
      try {
        let res = await api.post('vaults', data)
        dispatch('getVaults')
      } catch (error) {
        console.error(error)
      }
    },

    async deleteVault({ dispatch }, data) {
      try {
        let res = await api.delete(`vaults/${data.id}`)
        dispatch('getVaults')
      } catch (error) {
        console.error(error)
      }
    },
    //#endregion

    //#region  --VAULTKEEPS --
    async getKeepsByVault({ commit }, data) {
      try {
        let res = await api.get(`vaultkeeps/${data}`)
        commit('setKeeps', res.data)
      } catch (error) {
        console.error(error)
      }
    },

    async createVaultKeep({ dispatch }, data) {
      try {
        let res = await api.post('vaultkeeps', data)
      } catch (error) {
        console.error(error)
      }
    },

    async removeVaultKeep({ dispatch }, data) {
      try {
        let res = await api.put('vaultkeeps', data)
        dispatch('getKeepsByVault', data.vaultId)
      } catch (error) {
        console.error(error)
      }
    }
    ////#endregion
  }
})
