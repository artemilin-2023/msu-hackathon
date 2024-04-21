<script setup lang="ts">
import { ref } from 'vue';
import { mdiMagnify, mdiHome } from '@mdi/js';
import { useRouter } from 'vue-router';

const { push, currentRoute } = useRouter();

const searchText = ref(currentRoute.value?.query['q'] ?? '');

function unfocusAndSearch() {
	if (document.activeElement instanceof HTMLInputElement) {
		document.activeElement.blur();
	}
	doSearch();
}

function doSearch() {
	console.log(currentRoute.value.query);
	push({
		query: {
			...currentRoute.value.query,
			q: searchText.value,
		},
	});
}
</script>

<template>
	<v-sheet width="100vw" height="100vh" class="px-5 d-flex flex-column">
		<v-sheet elevation2 style="z-index: 2"
			><v-text-field
				v-model="searchText"
				autofocus
				hide-details="auto"
				style="padding: 2vh 3vw"
				variant="solo"
				density="comfortable"
				label="Найдите что-нибудь"
				placeholder="Физика"
				clearable
				@update:model-value="doSearch"
				@keydown.enter.prevent="unfocusAndSearch"
			>
				<template #prepend>
					<v-icon
						:icon="mdiHome"
						class="mx-0"
						@click="push({ path: '/', query: currentRoute.query })"
					/> </template
				><template #append>
					<v-icon :icon="mdiMagnify" class="mx-0" @click="unfocusAndSearch" /> </template></v-text-field
		></v-sheet>
		<v-sheet>
			
		</v-sheet>
		<v-expansion-panels>
			<v-expansion-panel
				title="Title"
				text="Lorem ipsum dolor sit amet consectetur adipisicing elit. Commodi, ratione debitis quis est labore voluptatibus! Eaque cupiditate minima"
			>
			</v-expansion-panel>
			<v-expansion-panel
				title="Title"
				text="Lorem ipsum dolor sit amet consectetur adipisicing elit. Commodi, ratione debitis quis est labore voluptatibus! Eaque cupiditate minima"
			>
			</v-expansion-panel>
			<v-expansion-panel
				title="Title"
				text="Lorem ipsum dolor sit amet consectetur adipisicing elit. Commodi, ratione debitis quis est labore voluptatibus! Eaque cupiditate minima"
			>
			</v-expansion-panel>
		</v-expansion-panels>
	</v-sheet>
</template>
