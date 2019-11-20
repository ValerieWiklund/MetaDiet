<template>
  <div id="create-keep-modal" class="modal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Add a keep</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="addKeep()">
            <div class="form-group">
              <label for="name">Name</label>
              <input
                type="text"
                class="form-control"
                id="name"
                placeholder="Enter name"
                v-model="newKeep.name"
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
                v-model="newKeep.description"
                required
              />
              <div class="form-group">
                <label for="img">Img Url</label>
                <input
                  type="text"
                  class="form-control"
                  id="img"
                  placeholder="Enter img url"
                  v-model="newKeep.img"
                />
              </div>
              <div class="form-check">
                <label for="isPrivate">Make Private?</label>
                <input
                  type="checkbox"
                  class="form-check-input ml-2"
                  id="isPrivate"
                  placeholder="Enter private or public"
                  v-model="newKeep.isPrivate"
                />
              </div>
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
  name: "create-keep-modal",
  data() {
    return {
      newKeep: {}
    };
  },
  computed: {
    // board() {
    //   return this.$store.state.activeBoard;
    // }
  },
  methods: {
    addKeep() {
      this.$store.dispatch("addKeep", this.newKeep);
      this.newKeep = {};
      $(".close").click();
    }
  },
  components: {}
};
</script>




<style scoped>
</style>