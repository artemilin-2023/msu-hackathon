<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { mdiMagnify, mdiHome } from '@mdi/js';
import { useRouter } from 'vue-router';

const { push, currentRoute } = useRouter();

const searchText = ref(currentRoute.value?.query['q'] ?? '');

// const foundItems = ref([]);

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

onMounted(() => {});
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
		<v-sheet class="d-flex flex-column flex-xl-row flex-lg-row flex-md-row"
			><v-autocomplete label="Курс" :items="[1, 2, 3, 4, 5, 6, 7, 8]" multiple></v-autocomplete
			><v-autocomplete
				label="Предмет"
				:items="['Математический анализ', 'Линейная алгебра', 'Общая физика', 'Georgia', 'Texas', 'Wyoming']"
				multiple
			></v-autocomplete
			><v-autocomplete
				label="Тип материала"
				:items="['California', 'Colorado', 'Florida', 'Georgia', 'Texas', 'Wyoming']"
				multiple
			></v-autocomplete
		></v-sheet>
		<!-- <v-data-iterator :items="mice" :items-per-page="itemsPerPage">
			<template #header="{ page, pageCount, prevPage, nextPage }">
				<h1 class="text-h4 font-weight-bold d-flex justify-space-between mb-4 align-center">
					<div class="text-truncate">Most popular mice</div>

					<div class="d-flex align-center">
						<v-btn class="me-8" variant="text" @click="onClickSeeAll">
							<span class="text-decoration-underline text-none">See all</span>
						</v-btn>

						<div class="d-inline-flex">
							<v-btn
								:disabled="page === 1"
								class="me-2"
								icon="mdi-arrow-left"
								size="small"
								variant="tonal"
								@click="prevPage"
							></v-btn>

							<v-btn
								:disabled="page === pageCount"
								icon="mdi-arrow-right"
								size="small"
								variant="tonal"
								@click="nextPage"
							></v-btn>
						</div>
					</div>
				</h1>
			</template>

			<template #default="{ items }">
				<v-row>
					<v-col v-for="(item, i) in items" :key="i" cols="12" sm="6" xl="3">
						<v-sheet border>
							<v-img
								:gradient="`to top right, rgba(255, 255, 255, .1), rgba(${item.raw.color}, .15)`"
								:src="item.raw.src"
								height="150"
								cover
							></v-img>

							<v-list-item
								:title="item.raw.name"
								density="comfortable"
								lines="two"
								subtitle="Lorem ipsum dil orei namdie dkaf"
							>
								<template v-slot:title>
									<strong class="text-h6">
										{{ item.raw.name }}
									</strong>
								</template>
							</v-list-item>

							<v-table class="text-caption" density="compact">
								<tbody>
									<tr align="right">
										<th>DPI:</th>

										<td>{{ item.raw.dpi }}</td>
									</tr>

									<tr align="right">
										<th>Buttons:</th>

										<td>{{ item.raw.buttons }}</td>
									</tr>

									<tr align="right">
										<th>Weight:</th>

										<td>{{ item.raw.weight }}</td>
									</tr>

									<tr align="right">
										<th>Wireless:</th>

										<td>{{ item.raw.wireless ? 'Yes' : 'No' }}</td>
									</tr>

									<tr align="right">
										<th>Price:</th>

										<td>${{ item.raw.price }}</td>
									</tr>
								</tbody>
							</v-table>
						</v-sheet>
					</v-col>
				</v-row>
			</template>

			<template #footer="{ page, pageCount }">
				<v-footer class="justify-space-between text-body-2 mt-4" color="surface-variant">
					Total mice: {{ mice.length }}

					<div>Page {{ page }} of {{ pageCount }}</div>
				</v-footer>
			</template>
		</v-data-iterator> -->
	</v-sheet>
</template>
