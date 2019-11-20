<template>
  <div>
    <div class="home">
      <h1 class="text-white" v-if="user.id">Welcome to Keepr, {{user.username}}</h1>
      <h1 class="text-white" v-else>Welcome to Keepr</h1>
      <button class="btn btn-primary btn-sm m-2" v-if="user.id" @click="logout">logout</button>
      <router-link class="btn btn-primary" v-else :to="{name: 'login'}">Login</router-link>
      <button class="btn btn-primary btn-sm" v-if="user.id" @click="goDashboard">Your Dashboard</button>
    </div>
    <div class="row">
      <keep v-for="keep in keeps" :keepProp="keep" :key="keep.id" />
    </div>
  </div>
</template>

<script>
import Keep from "../components/KeepComp";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },

    goDashboard() {
      this.$router.push({ name: "dashboard" });
    }
  },
  components: { Keep }
};
</script>