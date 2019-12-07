<template>
  <div class="vault card text-white bg-light mb-1" style="width: 90%;">
    <div class="card-body">
      <h5 class="card-title">{{vaultProp.name}}</h5>
      <p class="card-text">{{vaultProp.description}}</p>
      <button class="btn btn-primary btn-sm mr-1" @click="viewVault(vaultProp)">View Vault</button>
      <button class="btn btn-primary btn-sm ml-1" @click="deleteVault(vaultProp)">Delete Vault</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "vault",
  props: ["vaultProp"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    deleteVault(vault) {
      this.$store.dispatch("deleteVault", vault);
    },

    viewVault(vault) {
      this.$store.commit("setActiveVault", vault);
      let data = {};
      this.$store.commit("setKeeps", data);
      let vaultId = vault.id;
      this.$router.push({ name: "vault", params: { vaultId } });
    }
  },
  components: {}
};
</script>
<style scoped>
</style>