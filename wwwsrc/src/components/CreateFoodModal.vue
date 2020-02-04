<template>
  <div id="create-food-modal" class="modal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Add a food</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="addFood()">
            <div class="form-group">
              <label for="name">Name</label>
              <input
                type="text"
                class="form-control"
                id="name"
                placeholder="Enter name"
                v-model="newFood.name"
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
                v-model="newFood.description"
                required
              />
              </div>
              <div class="form-group">
                <label for="category">Category</label>
                <input
                  type="text"
                  class="form-control"
                  id="category"
                  placeholder="Enter category"
                  v-model="newFood.category"
                />
              </div>
              <div class="form-check">
                <label for="phase1">Phase 1 Food?</label>
                <input
                  type="checkbox"
                  class="form-check-input ml-2"
                  id="phase1"
                  placeholder="Is this a Phase 1 food?"
                  v-model="newFood.phase1"
                />
              </div>
              <div class="form-check">
                <label for="phase2">Phase 2 Food?</label>
                <input
                  type="checkbox"
                  class="form-check-input ml-2"
                  id="phase2"
                  placeholder="Is this a Phase 2 food?"
                  v-model="newFood.phase2"
                />
              </div>
              <div class="form-check">
                <label for="phase3">Phase 3 Food?</label>
                <input
                  type="checkbox"
                  class="form-check-input ml-2"
                  id="phase3"
                  placeholder="Is this a Phase 3 food?"
                  v-model="newFood.phase3"
                />
              </div>
                <div class="form-group">
              <label for="servingnum">Serving Size Number</label>
              <input
                type="number"
                class="form-control"
                id="servingnum"
                placeholder="Enter Serving size number"
                v-model="newFood.servingNum"
                required
              />
              </div>
              <div class="form-group">
                <label for="sizedescription">Serving Size Description</label>
                <input type="text" class="form-control" id="sizedescription" placeholder="Enter Serving Size Description" v-model="newFood.sizeDescription" />
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
  name: "create-food-modal",
  data() {
    return {
      newFood: {}
    };
  },
  computed: {
    // board() {
    //   return this.$store.state.activeBoard;
    // }
  },
  methods: {
    // addKeep() {
    //   this.$store.dispatch("addKeep", this.newKeep);
    //   this.newKeep = {};
    //   $(".close").click();
    // }
  },
  components: {}
};
</script>