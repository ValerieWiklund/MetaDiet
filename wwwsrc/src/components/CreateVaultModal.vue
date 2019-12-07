<template>
  <div id="create-vault-modal" class="modal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Add a Vault</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="addVault()">
            <div class="form-group">
              <label for="name">Name</label>
              <input
                type="text"
                class="form-control"
                id="name"
                placeholder="Enter name"
                v-model="newVault.name"
                required
              />
            </div>
            <div class="form-group">
              <label for="description">Description</label>
              <input
                type="text"
                class="form-control"
                id="description"
                placeholder="Enter description"
                v-model="newVault.description"
                required
              />
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "create-vault-modal",
  data() {
    return {
      newVault: {}
    };
  },
  computed: {
    // board() {
    //   return this.$store.state.activeBoard;
    // }
  },
  methods: {
    addVault() {
      this.$store.dispatch("addVault", this.newVault);
      this.newVault = {};
      $(".close").click();
    }
  },
  components: {}
};
</script>




<style scoped>
</style>