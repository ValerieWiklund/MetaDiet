<template>
  <div>
    <div class="profile">
      <h3 class="text-black">WELCOME!</h3>
      <h1>{{user.username}}</h1>
    </div>
  </div>
</template>

<script>
export default {
  name: "profile",
  // mounted() {
  //   this.$store.dispatch("getKeeps");
  // },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {}
  // components: { Keep }
};
</script>