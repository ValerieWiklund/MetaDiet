<template>
  <div>
    <div class="home">
      <h1 v-if="user.id">Welcome to The Meta Diet, {{user.username}}</h1>
      <h1 v-else>Welcome to The Meta Diet</h1>
      <button class="btn btn-primary btn-sm m-2" v-if="user.id" @click="logout">logout</button>
      <router-link class="btn btn-primary" v-else :to="{name: 'login'}">Login</router-link>
      <button class="btn btn-primary btn-sm" v-if="user.id" @click="goProfile">Your Profile</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  // mounted() {
  //   this.$store.dispatch("getKeeps");
  // },
  computed: {
    user() {
      return this.$store.state.user;
    }
    // keeps() {
    //   return this.$store.state.keeps;
    // }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },

    goProfile() {
      this.$router.push({ name: "profile" });
    }
  }
  // components: { Keep }
};
</script>