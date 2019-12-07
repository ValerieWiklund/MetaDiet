<template>
  <div>
    <div class="home">
      <h1 class="text-white" v-if="user.id">Welcome to MetaDiet, {{user.username}}</h1>
      <h1 class="text-white" v-else>Welcome to MetaDiet - The Fast Metabolism Diet App</h1>
      <button class="btn btn-primary btn-sm m-2" v-if="user.id" @click="logout">logout</button>
      <router-link class="btn btn-primary" v-else :to="{name: 'login'}">Login</router-link>
      <button class="btn btn-primary btn-sm" v-if="user.id" @click="goDashboard">Your Dashboard</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  mounted() {},
  computed: {
    user() {
      return this.$store.state.user;
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
  components: {}
};
</script>