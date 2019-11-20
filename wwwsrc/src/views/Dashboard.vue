<template>
  <div class="container-fluid dashboard">
    <h1>Welcome {{user.username}}</h1>
    <button class="btn btn-primary btn-sm mr-2" v-if="user.id" @click="logout">logout</button>
    <button class="btn btn-primary btn-sm ml-2" @click="goHome">Home</button>
    <div class="row justify-content-center">
      <div class="col-7">
        <h4>Your Keeps</h4>
        <CreateKeepModal />
        <button
          class="btn btn-primary btn-sm mb-2"
          data-toggle="modal"
          data-target="#create-keep-modal"
        >Create Keep</button>
        <div class="row">
          <keep v-for="keep in keeps" :keepProp="keep" :key="keep.id" />
        </div>
      </div>
      <div class="offset-1 col-3 justify-content-center">
        <h4>Your Vaults</h4>
        <CreateVaultModal />
        <button
          class="btn btn-primary btn-sm mb-2"
          data-toggle="modal"
          data-target="#create-vault-modal"
        >Create vault</button>
        <vault v-for="vault in vaults" :vaultProp="vault" :key="vault.id" />
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "../components/KeepComp";
import Vault from "../components/VaultComp";
import CreateKeepModal from "../components/CreateKeepModal";
import CreateVaultModal from "../components/CreateVaultModal";
export default {
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getKeepsByUser");
    this.$store.dispatch("getVaults");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },

    goHome() {
      this.$router.push({ name: "home" });
    }
  },
  components: { Keep, Vault, CreateKeepModal, CreateVaultModal }
};
</script>
<style scoped>
.dashboard {
  color: white;
}
</style>
