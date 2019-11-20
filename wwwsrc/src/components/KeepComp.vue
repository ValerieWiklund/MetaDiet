<template>
  <!-- <div class="card-group" style="width: 12rem;"> -->
  <div class="keep card text-white bg-primary m-3" style="width: 12rem;">
    <img v-bind:src="`${keepProp.img}`" class="card-img-top" alt="..." @click="viewKeep(keepProp)" />
    <div class="card-body">
      <h5>{{keepProp.name}}</h5>
      <span class="badge badge-pill badge-success mr-1" @click="viewKeep(keepProp)">
        <i class="far fa-eye"></i>
        {{keepProp.views}}
      </span>
      <span class="badge badge-pill badge-success ml-1">
        <i class="fas fa-lock"></i>
        {{keepProp.keeps}}
      </span>
    </div>
    <div class="card-footer">
      <button
        class="btn btn-warning btn-sm mr-2"
        v-if="$route.name ==='vault'"
        @click="removeVaultKeep"
      >Remove from Vault</button>
      <button
        class="btn btn-warning btn-sm"
        v-if="$route.name ==='dashboard'"
        @click="deleteKeep(keepProp)"
      >Delete Keep</button>
    </div>
  </div>
  <!-- </div> -->
</template>

<script>
export default {
  name: "keep",
  props: ["keepProp"],
  data() {
    return {
      newVaultId: ""
    };
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    deleteKeep(keepProp) {
      if (!keepProp.isPrivate) {
        alert("you cannot delete a public keep");
      } else {
        let data = this.keepProp.id;
        this.$store.dispatch("deleteKeep", data);
      }
    },

    addToVault() {
      let data = {
        vaultId: this.$route.params.vaultId,
        keepId: this.keepProp.id
      };
      this.$store.dispatch("createVaultKeep", data);
    },

    viewKeep(keepProp) {
      if (keepProp.userId) {
        keepProp.views++;
        this.$store.dispatch("editKeep", keepProp);
      }
      this.$router.push({
        name: "keep",
        params: { keepId: this.keepProp.id }
      });
    },

    removeVaultKeep() {
      let data = {
        vaultId: this.$route.params.vaultId,
        keepId: this.keepProp.id
      };

      this.$store.dispatch("removeVaultKeep", data);
    }
  },
  components: {}
};
</script>
<style scoped>
/* .card-columns {
  display: inline-block;
} */
img {
  width: 100%;
  height: auto;
}
</style>